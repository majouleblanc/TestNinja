﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideosAsCsv();
    }

    class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideosAsCsv()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();
                return videos;
            }
        }

    }
}
