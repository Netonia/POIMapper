# PRD - POI Mapper Blazor WebAssembly

## Objectif
POI Mapper est une application Blazor WebAssembly permettant aux utilisateurs de créer, visualiser et gérer des points d’intérêt (POI) sur une carte interactive avec données personnalisables et export.

## Public cible
- Développeurs et testeurs
- Urbanistes et organisateurs d’événements
- Toute personne souhaitant gérer des points d’intérêt sur une carte

## Fonctionnalités principales

### 1. Carte interactive
- Intégration avec Leaflet.js via LeafletForBlazor
- Zoom, déplacement, recherche par adresse ou coordonnées

### 2. Ajout de points d’intérêt
- Saisie manuelle : nom, description, catégorie, coordonnées GPS
- Drag & drop pour positionner sur la carte
- Catégorisation : restaurant, monument, parc, service, etc.

### 3. Édition et suppression
- Modification en ligne via panneau latéral ou popup
- Suppression simple des POI

### 4. Filtrage et recherche
- Filtrage par catégorie, distance, ou texte
- Tri par nom ou date d’ajout

### 5. Templates Liquid (optionnel)
- Génération d’export personnalisés (HTML, CSV, JSON) via Fluid.Core
- Exemple : "{{ name }} - {{ category }} - {{ lat }}, {{ lon }}"

### 6. Export et partage
- Export JSON ou CSV des POI
- Copier dans le presse-papier
- Option future : partage via URL ou QR code

### 7. Stockage local
- Persistance via IndexedDB / localStorage
- Gestion de multiples projets et POI

## Architecture technique
- Blazor WebAssembly .NET 9.0 – frontend 100% client
- LeafletForBlazor – intégration de la carte (https://github.com/ichim/LeafletForBlazor-NuGet)
- Fluid.Core – rendu des templates Liquid pour export
- StorageService – persistance locale
- POIService – CRUD des POI côté client

## UI/UX
- Panneau gauche : liste des POI, filtres, recherche
- Panneau central : carte interactive avec marqueurs
- Panneau droit (optionnel) : template Liquid + prévisualisation export
- Boutons : Ajouter POI, Générer Export, Copier, Supprimer

## Extensions possibles
- Intégration API externe pour enrichir POI (ex : météo, photos, horaires)
- Multi-utilisateur avec synchronisation via WebAPI
- Clustering automatique des POI pour cartes denses
- Mode itinéraire : calculer trajet optimal passant par plusieurs POI

## Exemple de workflow utilisateur
1. L'utilisateur crée un POI "Tour Eiffel" avec nom, catégorie, description et coordonnées.
2. Il place le POI sur la carte via drag & drop.
3. Il filtre la carte pour afficher uniquement monuments.
4. Il génère un export CSV avec les POI visibles.

## GitHub Pages
- GitHub Action workflow deploy.yml
