using AutoMapper;
using Domain.Models;
using Vendas.Controllers;
using Vendas.Models;

namespace Vendas
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<VendaPost, Venda>();
            CreateMap<ItemVendaDto, ItemVenda>();
            CreateMap<VendedorDto, Vendedor>();
            CreateMap<StatusVendaPost, StatusVenda>();

            CreateMap<Venda, VendaPost>();
            CreateMap<Vendedor, VendedorDto>();
            CreateMap<ItemVenda, ItemVendaDto>();
            CreateMap<StatusVenda, StatusVendaPost>();

            CreateMap<Venda, VendaGet>();
            CreateMap<Vendedor, VendedorDto>();
            CreateMap<ItemVenda, ItemVendaDto>();
            CreateMap<StatusVenda, StatusVendaPost>();
        }
    }
}
