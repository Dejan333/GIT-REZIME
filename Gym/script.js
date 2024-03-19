function searchState(stateName) {
    window.open(`https://www.google.com/maps/search/${stateName}`);
  }
  
  const mapDots = document.querySelectorAll('.map-dot');
  mapDots.forEach((dot) => {
    const stateName = dot.getAttribute('data-state');
    dot.addEventListener('click', () => {
      searchState(stateName);
    });
  });
  