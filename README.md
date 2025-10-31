# POI Mapper

POI Mapper is a Blazor WebAssembly application that allows users to create, visualize, and manage Points of Interest (POI) on an interactive map with customizable data and export capabilities.

## Features

### 1. Interactive Map
- Integration with Leaflet.js via LeafletForBlazor
- Zoom, pan, and navigate the map
- Search by address or coordinates

### 2. Point of Interest Management
- **Add POIs**: Manually enter name, description, category, and GPS coordinates
- **Edit POIs**: Modify existing points of interest
- **Delete POIs**: Remove unwanted POIs
- **Categories**: Restaurant, Monument, Park, Service, Shopping, Hotel, Hospital, School, Museum, Other

### 3. Filtering and Search
- Filter by category
- Search by text (name or description)
- Sort by name or creation date

### 4. Liquid Templates (Optional)
- Generate custom exports (HTML, CSV, JSON) using Fluid.Core
- Example template: `{{ name }} - {{ category }} - {{ lat }}, {{ lon }}`

### 5. Export and Share
- Export as JSON
- Export as CSV
- Export with custom Liquid templates
- Copy to clipboard functionality

### 6. Local Storage
- Persistence via localStorage
- All data is stored locally in your browser
- Manage multiple POIs in a single project

## Technologies

- **Blazor WebAssembly .NET 9.0** – 100% client-side frontend
- **LeafletForBlazor** – Interactive map integration
- **Fluid.Core** – Liquid template rendering for exports
- **Bootstrap 5** – UI framework

## Getting Started

### Prerequisites
- .NET 9.0 SDK

### Running Locally

1. Clone the repository:
```bash
git clone https://github.com/Netonia/POIMapper.git
cd POIMapper
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the application:
```bash
dotnet run
```

4. Open your browser and navigate to `https://localhost:5001` (or the URL shown in the console)

### Building for Production

```bash
dotnet publish -c Release
```

The output will be in `bin/Release/net9.0/publish/wwwroot`

## Usage

1. **Create a POI**: Click the "+ Add POI" button, fill in the details, and save
2. **View POIs**: See all your POIs in the left panel
3. **Filter**: Use the search box or category dropdown to filter POIs
4. **Edit/Delete**: Click the Edit or Delete button on any POI
5. **Export**: Use the right panel to export your POIs in various formats

## Deployment

This project includes a GitHub Actions workflow that automatically deploys to GitHub Pages on push to the main branch.

## Future Enhancements

- Integration with external APIs for enriching POI data (weather, photos, hours)
- Multi-user support with synchronization via Web API
- Automatic clustering of POIs for dense maps
- Route calculation: optimal path through multiple POIs
- Import POIs from various file formats

## License

This project is open source and available under the MIT License.
