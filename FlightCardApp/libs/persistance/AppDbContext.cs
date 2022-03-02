﻿using FlightCardApp.libs.core;
using FlightCardApp.libs.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCardApp.libs.persistance
{
    public class AppDbContext:DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public AppDbContext()
        {


        }
      

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions, IDomainEventDispatcher domainEventDispatcher) :base(dbContextOptions)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        public DbSet<FlightPlaning> FlightPlanings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Airport> AirPorts { get; set; }
        public DbSet<FlightTicket> FlightTickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=FlightDB;Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }


        private void _dispatchDomainEvents()
        {

            var domainEventEntities = ChangeTracker.Entries<IEntity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                foreach (var @event in entity.DomainEvents)
                {
                   // DomainEvent.Raise(@event);
                    _domainEventDispatcher.Dispatch(@event);
                }

            }
        }

        public override int SaveChanges()
        {
            _dispatchDomainEvents();
            // kayıt işlemi öncesinde ilgili eventleri çalıştır.

            return base.SaveChanges();
        }


    }
}
