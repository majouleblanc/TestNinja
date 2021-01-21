using NUnit.Framework;
using TestNinja.Mocking;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Net;

namespace TestNinja.Mocking.Tests
{
    [TestFixture()]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _mockFileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _mockFileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_mockFileDownloader.Object);
        }

        [Test()]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _mockFileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("", null);

            Assert.IsFalse(result);
        }

        [Test()]
        public void DownloadInstaller_DownloadSucceeded_ReturnsTrue()
        {
            _mockFileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            Assert.IsTrue(_installerHelper.DownloadInstaller("", ""));
        }
    }
}