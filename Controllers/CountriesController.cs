using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.DTOs;
using BookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // api/countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country_DTO>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countriesDTO = new List<Country_DTO>();

            foreach(var country in countries)
            {
                countriesDTO.Add(new Country_DTO { Id = country.Id, Name = country.Name });
            }

            return Ok(countriesDTO);
        }

        // api/countries/countryId
        [HttpGet("{countryId}")]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(404)] // Not Found
        [ProducesResponseType(200, Type = typeof(Country_DTO))] // Ok Request
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var country = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
                return BadRequest();

            var countryDTO = new Country_DTO()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDTO);
        }

        // api/countries/authors/authorId
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(404)] // Not Found
        [ProducesResponseType(200, Type = typeof(Country_DTO))] // Ok Request
        public IActionResult GetCountryOfAnAuthor(int authorId)
        {
            // Validate If Author Exists

            var country = _countryRepository.GetCountryOfAnAuthor(authorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDTO = new Country_DTO()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDTO);
        }
    }

}