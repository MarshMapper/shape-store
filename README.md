# shape-store

.NET 8 service using EF Core and NetTopologySuite (NTS) to manage spatial data.  The advantage of
NetTopologySuite over previous approaches that relied on the SqlGeography type is that it can work
with multiple data stores including SQL Server and PostgreSQL / PostGIS.

This project is currently using only System.Text.Json and relies on the NTS support for it, though that is
currently a subset of the full features available.  

Endpoints are available for CRUD operations on Locations and related entities.  An additional endpoint returns
all the locations in GeoJSON format.  That endpoint also supports a query string to filter the results by distance from a point

     /locations/geojson?lat=44.5&lon=-74.0&radius=50

## Testing
The Web folder contains a file shape-store.http that can be used to test the API.
