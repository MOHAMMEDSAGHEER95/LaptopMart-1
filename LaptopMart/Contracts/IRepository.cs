﻿using System.Collections.Generic;

namespace LaptopMart.Contracts
{
    public interface IRepository<T>
    {
        void Create(T t);
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Update(T t);
        void Delete(int id);

    }
}