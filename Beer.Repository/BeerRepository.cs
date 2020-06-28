using Beer.Interfaces;
using Beer.Models;
using Beer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Beer.Repository
{
    public sealed class BeerRepository : IBeer
    {
        private readonly BeerDBContext _dbContext;
        public BeerRepository(BeerDBContext dbContext) => _dbContext = dbContext;

        public async Task AddBeer(BeerModel _beer)
        {
            // Adding Beer Data
            var beerEntity = new BeerModel();            
            beerEntity.Name = _beer.Name;
            beerEntity.Type = _beer.Type;
            await _dbContext.Beers.AddAsync(beerEntity);           
        }

        public async Task<List<BeerViewModel>> GetAllBeers()
        {
            return await (from beer in _dbContext.Beers
                          select new BeerViewModel {
                              BeerName = beer.Name,
                              BeerType = beer.Type
                          }).ToListAsync();
        }

        public async Task<List<BeerViewModel>> FilterBeersByName(string _filter)
        {
            return await _dbContext.Beers
            .Where(n => n.Name.Contains(_filter.ToLower()))
            .Select(beerFilter => new BeerViewModel
            {
                BeerName = beerFilter.Name,
                BeerType = beerFilter.Type
            }).ToListAsync();
        }
       
    }
}
