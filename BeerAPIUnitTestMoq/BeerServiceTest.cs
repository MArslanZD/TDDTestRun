using Beer.Interfaces;
using Beer.Models;
using Beer.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BeerAPIUnitTestMoq
{
    public class BeerServiceTest
    {
       
   
        [Fact] 
        public void GetAllBeers_ReturnsBeers()
        {
            //Arrange
                var service = new Mock<IBeer>();            
            var beers =  GetFakeData();
            service.Setup(x => x.GetAllBeers()).Returns(beers);
            var controller = new BeerCollection.Controllers.Beer(service.Object);

            //Act

            var results = controller.GetAllBeers();
            var count = results.Result.Count;
            //Assert
             Assert.Equal(count,4);
        }

        private async Task<List<BeerViewModel>> GetFakeData()
        {
            var i = 1;
            List<BeerViewModel> b = new List<BeerViewModel>();
            b.Add(new BeerViewModel{ BeerName ="b1", BeerType="x1"});
            b.Add(new BeerViewModel{  BeerName = "b1", BeerType = "x1" });
            b.Add(new BeerViewModel{  BeerName = "b2", BeerType = "x2" });
            b.Add(new BeerViewModel { BeerName = "b3", BeerType = "x3" });

            return b;
        }
    }
}
