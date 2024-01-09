using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija2.Dtos;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<CarDto, Car>();
            Mapper.CreateMap < Rental, RentalDto>();
            Mapper.CreateMap<RentalDto, Rental>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

        }
    }
}