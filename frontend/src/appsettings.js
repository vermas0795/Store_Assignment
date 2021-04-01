(function (window) {
  window.__env = window.__env || {};
  // Change below API url as per environment 
 window.__env.apiUrl = 'https://localhost:44379/api/entity/';
  // Change this below value to false in prod environment
 window.__env.production= true;
}(this));
