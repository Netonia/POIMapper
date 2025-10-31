window.mapHelper = {
    map: null,
    markers: [],
    
    initMap: function(elementId, lat, lon, zoom) {
        if (this.map) {
            this.map.remove();
        }
        
        this.map = L.map(elementId).setView([lat, lon], zoom);
        
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
            maxZoom: 19
        }).addTo(this.map);
        
        return true;
    },
    
    clearMarkers: function() {
        if (this.markers) {
            this.markers.forEach(marker => marker.remove());
        }
        this.markers = [];
    },
    
    addMarker: function(lat, lon, name, description, category) {
        if (!this.map) return;
        
        const marker = L.marker([lat, lon]).addTo(this.map);
        
        const popupContent = `
            <div>
                <h6>${name}</h6>
                <p>${description}</p>
                <small class="text-muted">${category}</small>
            </div>
        `;
        
        marker.bindPopup(popupContent);
        marker.bindTooltip(name);
        
        this.markers.push(marker);
    },
    
    fitBounds: function(pois) {
        if (!this.map || !pois || pois.length === 0) return;
        
        const bounds = L.latLngBounds(pois.map(poi => [poi.latitude, poi.longitude]));
        this.map.fitBounds(bounds, { padding: [50, 50] });
    }
};
