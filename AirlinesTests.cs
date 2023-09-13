using Airlines.AirDbContext;
using Airlines.Controllers;
using Airlines.Model;
using Airlines.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System.Runtime.CompilerServices;

namespace AirlinesXUnit
{
    
    public class AirlinesTests
    {

        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepository<Airline>> _repository;
        private readonly AirlinesController _cont;
        public AirlinesTests()
        {
          
          _repository=new Mock<IRepository<Airline>>();
            _mapper = new Mock<IMapper>();
            _cont=new AirlinesController(_repository.Object,_mapper.Object);
        }

        [Fact]
        public void GetAll()
        {

            _repository.Setup(x => x.GetAll()).Returns(AilrineList());
            var result = _cont.Index();
            var resultData = result.Result as ViewResult;
            Assert.NotNull(resultData?.Model);
        }
        [Fact]
        public void GetNull()
        {

            _repository.Setup(x => x.GetAll()).Returns(AilrineNullList());
            var result = _cont.Index();
            var resultData = result.Result as ViewResult;
            Assert.Null(resultData?.Model);
        }
        [Theory]
        [InlineData("1401781f-6704-48a7-872b-8acd8660a6c4")]
        public void GetById(string id)
        {
            _repository.Setup(x => x.Get(id)).Returns(Get());
            var result = _cont.Details(id);
            var resultData = result.Result as ViewResult;
            Assert.NotNull(resultData?.Model);


        }
        [Fact]
        public void update()
        {
            Airline t = Get();
            _repository.Setup(x => x.Update(t)).Returns(true);
            var result=_cont.Edit(t);
            var resultData = result as RedirectToActionResult;
            Assert.True(resultData?.ActionName=="Index");
         
        }
        [Fact]
        public void Delete()
        {
           Airline t=Get();
           _repository.Setup(x=>x.Remove(t)).Returns(true);
            var result = _cont.Delete(t);
            var resultData = result as RedirectToActionResult;
            Assert.True(resultData?.ActionName == "Index");
        }
       
         public AirlinesMapper In()
        {
            return new AirlinesMapper() { FoundingYear=2000,OriginCountry="Russia",Name="Russian Airlines"};
        }
        public Airline Crea()
        {
            return new Airline() { Id = "1401781f-6704-48a7-872b-8acd8660a6c8", FoundingYear = 2000, OriginCountry = "Russia", Name = "Russian Airlines" };
        }

        public Airline Get() {
            return new Airline() { Id = "1401781f-6704-48a7-872b-8acd8660a6c4", Name = "Quantas", OriginCountry = "Australia", FoundingYear = 2001 };

        }
        public List<Airline> AilrineNullList()
        {
            return null;
        }

        public List<Airline> AilrineList()
        {
            return new List<Airline>()
            {
                new Airline(){Id="1401781f-6704-48a7-872b-8acd8660a6c4",Name="Quantas",OriginCountry="Australia",FoundingYear=2001},
                new Airline(){Id="1401781f-6704-48a7-872b-8acd8660a6c8",Name="AirIndia",OriginCountry="India",FoundingYear=2002 }
            };
        }
    }
}