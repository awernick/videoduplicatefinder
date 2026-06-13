# Build VDF.GUI from the awernick/videoduplicatefinder fork.
# Runtime base: jlesage/baseimage-gui (provides Xvfb + x11vnc + openbox).
#
# Exposed port: 5900 (VNC). Connect with any VNC client.
# WebVNC (noVNC) on port 5800 is also available but not mapped by default.

# Stage 1: Build VDF.GUI (self-contained linux-x64)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY VDF.Core/VDF.Core.csproj VDF.Core/
COPY VDF.GUI/VDF.GUI.csproj VDF.GUI/
RUN dotnet restore VDF.GUI/VDF.GUI.csproj -r linux-x64
COPY VDF.Core/ VDF.Core/
COPY VDF.GUI/ VDF.GUI/
RUN dotnet publish VDF.GUI/VDF.GUI.csproj -c Release -r linux-x64 --self-contained true -o /app

# Stage 2: Runtime with VNC
FROM jlesage/baseimage-gui:ubuntu-24.04

# System dependencies for Avalonia (X11) and VDF (ffmpeg).
RUN apt-get update && apt-get install -y --no-install-recommends \
    ffmpeg \
    libice6 \
    libsm6 \
    && rm -rf /var/lib/apt/lists/*

# Copy the self-contained VDF.GUI build.
COPY --from=build /app /app/VDF.GUI/

# Override the default startapp.sh to launch VDF.GUI instead of xterm.
RUN printf '#!/bin/sh\nexec /app/VDF.GUI/VDF.GUI\n' > /startapp.sh && chmod +x /startapp.sh

ENV APP_NAME="Video Duplicate Finder"
ENV DISPLAY_WIDTH=1920
ENV DISPLAY_HEIGHT=1080

EXPOSE 5900
