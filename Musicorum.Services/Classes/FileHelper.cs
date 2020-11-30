using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Musicorum.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Musicorum.Services.Classes
{
    public class FileHelper
    {
        public static byte[] FileAsBytes(IFormFile file)
        {
            if(file == null)
            {
                return null;
            }

            byte[] fileAsBytes;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                fileAsBytes = memoryStream.ToArray();
            };

            return fileAsBytes;
        }

        public static IFormFile BytesToFile(byte[] fileBytes)
        {
            if (fileBytes == null)
            {
                return null;
            }

            IFormFile file = null;

            using (var memoryStream = new MemoryStream(fileBytes))
            {
                file = new FormFile(memoryStream, 0, fileBytes.Length, "name", "fileName");
            };

            return file;
        }

        public static string GetVideoFilePath(byte[] fileBytes, int index)
        {
            string filePath = $"wwwroot/videos/video{index}.mp4";

            using (Stream t = new FileStream(filePath, FileMode.Create))
            {
                BinaryWriter b = new BinaryWriter(t);
                b.Write(fileBytes);
            }

            return $"/videos/video{index}.mp4";
        }

        public static string GetAudioFilePath(byte[] fileBytes, int index)
        {
            if(fileBytes == null)
            {
                return string.Empty;
            }

            string filePath = $"wwwroot/audios/audio{index}.mp3";

            using (Stream t = new FileStream(filePath, FileMode.Create))
            {
                BinaryWriter b = new BinaryWriter(t);
                b.Write(fileBytes);
            }

            return $"/audios/audio{index}.mp3";
        }

        public static void FillSongsUrls(IList<SongModel> songs)
        {
            foreach(SongModel song in songs)
            {
                song.SongPath = GetAudioFilePath(song.SongAsBytes, song.Id);
            }
        }

        public static void ClearVideoCache()
        {
            DirectoryInfo di = new DirectoryInfo("wwwroot/videos");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public static void ClearAudioCache()
        {
            DirectoryInfo di = new DirectoryInfo("wwwroot/audios");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
