﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackMyKid.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TranportCatalogEntities : DbContext
    {
        public TranportCatalogEntities()
            : base("name=TranportCatalogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MemberRole> MemberRoles { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationMember> OrganizationMembers { get; set; }
        public virtual DbSet<RoleDetail> RoleDetails { get; set; }
        public virtual DbSet<VehicleDetail> VehicleDetails { get; set; }
        public virtual DbSet<TripGeoLocation> TripGeoLocations { get; set; }
        public virtual DbSet<OrganizationRoute> OrganizationRoutes { get; set; }
        public virtual DbSet<RouteHalt> RouteHalts { get; set; }
        public virtual DbSet<RouteMember> RouteMembers { get; set; }
        public virtual DbSet<APP_ERR_LOG> APP_ERR_LOG { get; set; }
        public virtual DbSet<DriverDetail> DriverDetails { get; set; }
        public virtual DbSet<RouteTrip> RouteTrips { get; set; }
        public virtual DbSet<TripHaltTiming> TripHaltTimings { get; set; }
        public virtual DbSet<TripStatu> TripStatus { get; set; }
        public virtual DbSet<TripVehicleDriverDetail> TripVehicleDriverDetails { get; set; }
    }
}
