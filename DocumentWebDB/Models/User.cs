﻿using DocumentWebDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWebDB.Models
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual UserStatus Status { get; set; }

        public enum UserStatus
        {
            Active = 1,
            Ban = 2,
            Deleted = 0
        }
    }
}
