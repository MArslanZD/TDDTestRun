using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beer.Interfaces;
using Beer.Models;
using Beer.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeerCollection.Controllers
{
    [Produces("application/json")]
    [Route("api/beers")]
    [ApiController]
    public class Beer : ControllerBase
    {
        private readonly IBeer _beers;

        public Beer(IBeer beers) => _beers = beers;

        // Listing of All Beers
        [Route("fetch_beers")]
        [HttpGet]
        public async Task<List<BeerViewModel>> GetAllBeers()
        {            
                return await _beers.GetAllBeers();                                    
        }
        // Searching by Name all the Beers
        [Route("fetch_beers_by_name")]
        [HttpGet]
        public async Task<List<BeerViewModel>> FilterBeersByName( string _beerName)
        {
            return await _beers.FilterBeersByName(_beerName);
        }
        // Adding New Beers
        [Route("add_beer")]
        [HttpPost]
        public async Task<IActionResult> AddBeer([FromBody] BeerModel _addBeer)
        {
            try
            {
                await _beers.AddBeer(_addBeer);
                return new JsonResult(new { status = "Beer Entry Saved" });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
