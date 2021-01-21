using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.NUnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        public Mock<IFileReader> _fileReader { get; private set; }
        public VideoService _service { get; private set; }
        public Mock<IVideoRepository> _videoRepository { get; private set; }

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();

            _videoRepository = new Mock<IVideoRepository>();

            _service = new VideoService(_fileReader.Object, _videoRepository.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _service.ReadVideoTitle();

            //StringAssert.Contains("error", result.ToLower());
            Assert.That(result.ToLower(), Does.Contain("error"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCalled_ReturnListOfUnprocessedVideos()
        {
            
            var result = _service.GetUnprocessedVideosAsCsv();
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_EmptyVideoList_ReturnEmptyString()
        {
            _videoRepository.Setup(r => r.GetUnprocessedVideosAsCsv()).Returns(new List<Video>());

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.AreEqual("", result);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideoList_ReturnsStringWithTheirIds()
        {
            _videoRepository.Setup(r => r.GetUnprocessedVideosAsCsv()).Returns(new List<Video>()
            {
                new Video{Id=1},
                new Video{Id=2},
                new Video{Id=3},
            });

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.AreEqual("1,2,3", result);
        }
    }
}
