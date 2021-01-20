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

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();

            _service = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _service.ReadVideoTitle();

            //StringAssert.Contains("error", result.ToLower());
            Assert.That(result.ToLower(), Does.Contain("error"));
        }
    }
}
