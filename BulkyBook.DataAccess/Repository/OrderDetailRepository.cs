﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context): base(context)
        {
            _context = context;

        }

        

        public void Update(OrderDetail obj)
        {
            _context.OrderDetail.Update(obj);
        }
    }
}
