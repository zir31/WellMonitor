using AutoMapper;
using Moq;
using WellMonitor.Application.Dtos.Well;
using WellMonitor.Application.Services;
using WellMonitor.Core.Entities;
using WellMonitor.Core.Interfaces;
using WellMonitor.Core.Specifications.Well;

namespace Application.UnitTests
{
    public class WellServiceTests
    {
        private readonly WellService _sut;
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        public WellServiceTests()
        {
            _sut = new WellService(_mapperMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetActiveWellsByCompanyIdOrName_ShouldReturnActiveWellResponses()
        {
            //arrange
            var companyId = 1;
            var companyName = "First Company";
            var spec = new WellActiveByCompanyIdOrNameSpecification(companyId, companyName);
            
            var expectedEntities = new List<WellEntity>()
            {
                new WellEntity{
                Id = 2,
                Name = "Second Well",
                Active = true }
            }.AsEnumerable();

            var expectedResponses = new List<WellResponse>()
            {
                new WellResponse{
                Id = 2,
                Name = "Second Well",
                CompanyName = "First Company",
                Active = true } 
            }.AsEnumerable();

            _unitOfWorkMock.Setup(x => x.WellRepository.FindWithSpecificationPatternAsync(It.IsAny<WellActiveByCompanyIdOrNameSpecification>(), true))
                .ReturnsAsync(expectedEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<WellResponse>>(expectedEntities))
                .Returns(expectedResponses);

            //act
            var actualResponses = await _sut.GetActiveWellByCompanyIdOrCompanyNameAsync(companyId, companyName);

            //assert
            Assert.Equal(expectedResponses, actualResponses);
        }

        [Fact]
        public async Task GetWellByCompanyIdOrCompanyNameAsync_ShouldReturnWellResponses()
        {
            //arrange
            var companyId = 1;
            var companyName = "First Company";
            var spec = new WellByCompanyIdOrNameSpecification(companyId, companyName);

            var expectedEntities = new List<WellEntity>()
            {
                new WellEntity
                {
                    Id = 1,
                    Name = "First Well",
                    Active = false 
                },
                new WellEntity
                {
                    Id = 2,
                    Name = "Second Well",
                    Active = true 
                }
            }.AsEnumerable();

            var expectedResponses = new List<WellResponse>()
            {   
                new WellResponse
                {
                    Id = 1,
                    Name = "First Well",
                    CompanyName = "First Company",
                    Active = false 
                },
                new WellResponse
                {
                    Id = 2,
                    Name = "Second Well",
                    CompanyName = "First Company",
                    Active = true 
                }
            }.AsEnumerable();

            _unitOfWorkMock.Setup(x => x.WellRepository.FindWithSpecificationPatternAsync(It.IsAny<WellByCompanyIdOrNameSpecification>(), true))
                .ReturnsAsync(expectedEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<WellResponse>>(expectedEntities))
                .Returns(expectedResponses);

            //act
            var actualResponses = await _sut.GetWellByCompanyIdOrCompanyNameAsync(companyId, companyName);

            //assert
            Assert.Equal(expectedResponses, actualResponses);
        }

        [Fact]
        public async Task GetAllActiveWellsAsync_ShouldReturnWellResponses()
        {
            //arrange
            var spec = new WellActiveSpecification();

            var expectedEntities = new List<WellEntity>()
            {
                new WellEntity{
                Id = 2,
                Name = "Second Well",
                Active = true }
            }.AsEnumerable();

            var expectedResponses = new List<WellResponse>()
            {
                new WellResponse{
                Id = 2,
                Name = "Second Well",
                CompanyName = "First Company",
                Active = true }
            }.AsEnumerable();

            _unitOfWorkMock.Setup(x => x.WellRepository.FindWithSpecificationPatternAsync(It.IsAny<WellActiveSpecification>(), true))
                .ReturnsAsync(expectedEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<WellResponse>>(expectedEntities))
                .Returns(expectedResponses);

            //act
            var actualResponses = await _sut.GetAllActiveWellsAsync();

            //assert
            Assert.Equal(expectedResponses, actualResponses);
        }

        [Fact]
        public async Task GetWellWithDepthByIdBetweenDatesAsync_ShouldReturnWellDepthResponses()
        {
            //arrange
            var id = 1;
            var dateStart = DateTime.UtcNow.Date.AddDays(-5);
            var dateEnd = DateTime.UtcNow.Date;
            var spec = new WellByIdBetweenDatesSpecification(id, dateStart, dateEnd);

            var expectedEntities = new List<WellEntity>()
            {
                new WellEntity
                {
                    Id = 1,
                    Name = "First Well",
                    Active = false
                }
            };

            var expectedResponse = new WellDepthResponse
            {
                Name = "First Well",
                CompanyName = "First Company",
                Active = false,
                PassedDepth = 0,
            };

            _unitOfWorkMock.Setup(x => x.WellRepository.FindWithSpecificationPatternAsync(It.IsAny<WellByIdBetweenDatesSpecification>(), true))
                .ReturnsAsync(expectedEntities);
            _mapperMock.Setup(x => x.Map<WellDepthResponse>(expectedEntities.SingleOrDefault()))
                .Returns(expectedResponse);

            //act
            var actualResponse = await _sut.GetWellWithDepthByIdBetweenDatesAsync(id, dateStart, dateEnd);

            //assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task GetActiveWellWithDepthByCompanyIdBetweenDatesAsync_ShouldReturnWellDepthResponses()
        {
            //arrange
            var id = 1;
            var dateStart = DateTime.UtcNow.Date.AddDays(-5);
            var dateEnd = DateTime.UtcNow.Date;
            var spec = new WellActiveByCompanyIdBetweenDatesSpecification(id, dateStart, dateEnd);

            var expectedEntities = new List<WellEntity>()
            {
                new WellEntity
                {
                    Id = 2,
                    Name = "Second Well",
                    Active = true
                }
            }.AsEnumerable();

            var expectedResponse = new List<WellDepthResponse>()
            {
                new WellDepthResponse
                {
                Name = "Second Well",
                CompanyName = "First Company",
                Active = true,
                PassedDepth = 0
                }
            }.AsEnumerable();

            _unitOfWorkMock.Setup(x => x.WellRepository.FindWithSpecificationPatternAsync(It.IsAny<WellActiveByCompanyIdBetweenDatesSpecification>(), true))
                .ReturnsAsync(expectedEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<WellDepthResponse>>(expectedEntities))
                .Returns(expectedResponse);

            //act
            var actualResponse = await _sut.GetActiveWellWithDepthByCompanyIdBetweenDatesAsync(id, dateStart, dateEnd);

            //assert
            Assert.Equal(expectedResponse, actualResponse);
        }
    }
}
