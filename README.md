# shape-store

.NET 8 service using EF Core and NetTopologySuite to manage spatial data.  The advantage of
NetTopologySuite over previous approaches that relied on the SqlGeography type is that it can work
with multiple data stores including SQL Server and PostgreSQL / PostGIS.

NetTopologySuite was originally written using Newtonsoft.Json but support for System.Text.Json is being
added.  This project is currently using only System.Text.Json.