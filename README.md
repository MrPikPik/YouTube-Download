# YouTube-Download
A Windows grapical user interface for [youtube-dl](https://github.com/ytdl-org/youtube-dl "youtube-dl on GitHub") to download videos from YouTube

## Installation
### Building from source
1. Clone repository.
2. Download prebuilt [youtube-dl](https://ytdl-org.github.io/youtube-dl/download.html "youtube-dl download page") binary or build from source and place in `./YouTube Downloader/youtube-dl.exe`. The binary gets copied to the correct folder with a build.
3. Download prebuilt [ffmpeg](https://www.ffmpeg.org/download.html "ffmpeg download page") static binary or build from source and copy `ffpeg.exe` to `./YouTube Download/ffmpeg.exe`. The binary gets copied to the correct folder with a build.
If shared binaries are desired, adjust build settings accordingly or manually copy shared libraries after the build to the releases `bin` folder.
4. Build project in release configuration.

### Using prebuilt binaries
1. Get the [latest build](#).
2. Download prebuilt [youtube-dl](https://ytdl-org.github.io/youtube-dl/download.html "youtube-dl download page") binary and place in `YouTube Downloader/bin/youtube-dl.exe`.
3. Download prebuilt [ffmpeg](https://www.ffmpeg.org/download.html "ffmpeg download page") static binary and copy `ffpeg.exe` to `YouTube Download/bin/ffmpeg.exe`.

## Usage
To download a video from YouTube just copy the video URL and paste it into the input field at the bottom and press enter or click "Add". You can also drap and drop URLs from your browsers navigation bar or saved links from your computer. The programm will automatically test if the URL is valid and trim off excess data, like start timestamps and playlist data.

Once the URL has been resolved to a video title, select your desired format and click "Download".

The downloader will use the "best" preset youtube-dl provides. Custom download options can be specified by right clicking the video title in the list and choosing "Download with custom options...". For options, see [documentation of youtube-dl](https://github.com/ytdl-org/youtube-dl#options "youtube-dl documentation options section"). A full list of arguments will look like this: `youtube-dl.exe [your arguments] -o "../Downloads/%(title)s.%(ext)s" [video url]`.

Downloaded files can be found in the `YouTube Download/Downloads` folder.
