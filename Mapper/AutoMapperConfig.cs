using AutoMapper;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;

namespace NetCrud2.Mapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig() {
            // Buyer
            CreateMap<Buyer, BuyerResponse>();
            CreateMap<BuyerCreate, Buyer>();
            CreateMap<BuyerUpdate, Buyer>();
            //CreateMap<List<Buyer>, List<BuyerResponse>>();

            // Order
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderCreate, Order>();
            CreateMap<OrderUpdate, Order>();
            //CreateMap<List<Order>, List<OrderResponse>>();

            // OrderItem
            CreateMap<OrderItem, BuyerResponse>();
            CreateMap<OrderItemCreate, OrderItem>();
            CreateMap<OrderItemUpdate, OrderItem>();
            //CreateMap<List<OrderItem>, List<OrderItemResponse>>();

        }

    }
}
