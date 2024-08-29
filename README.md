# shape-store

.NET 8 service using EF Core and NetTopologySuite (NTS) to manage spatial data.  The advantage of
NetTopologySuite over previous approaches that relied on the SqlGeography type is that it can work
with multiple data stores including SQL Server and PostgreSQL / PostGIS.

This project is currently using only System.Text.Json and relies on the NTS support for it, though that is
currently a subset of the full features available.  

Endpoints are available for CRUD operations on Locations and related entities.  An additional endpoint returns
all the locations in GeoJSON format.

## Testing
The Web folder contains a .http file that can be used to test the API.

