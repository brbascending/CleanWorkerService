using System;
using System.Threading.Tasks;
using CleanWorkerService.Application.Common;
using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Domain.Entities;
using CleanWorkerService.Infrastructure.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Tests.Unit.Common;

public class CreateWeatherReportTests
{
    private IApplicationDbContext _dbContext = null;
    
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _dbContext = new ApplicationDbContext(options);
    }

    [Test]
    public async Task Add_WeatherReportsShouldNotBeEmptyAfterAdding()
    {
        // Arrange
        var createWeatherReport = new WeatherReportRepository(_dbContext);

        var report = new WeatherReport()
        {
            City = "Berlin",
            Created = new DateTime(1990, 1, 1),
            Temperature = 21
        };
        
        // Act
        await createWeatherReport.Create(report);
        
        // Assert
        _dbContext.WeatherReports.Should().ContainSingle();
    }
}