﻿using NetCrud2.Generics;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Models;

namespace NetCrud2.Mapper
{
    public interface IOrderMapper : IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse>
    {
    }
}
