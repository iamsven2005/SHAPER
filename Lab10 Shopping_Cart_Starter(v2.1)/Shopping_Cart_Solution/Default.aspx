<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Lazy Loading Example</title>
  <style>
    /* Optional: Style for the container */
    .image-container {
      display: flex;
      flex-wrap: wrap;
    }
    /* Optional: Style for each image */
    .lazy-image {
      width: 100px;
      height: 100px;
      margin: 5px;
      object-fit: cover;
    }
  </style>
</head>
<body>

<!-- Container for lazy-loaded images -->
<div class="image-container">
  <!-- Placeholder for the first image -->
  <img class="lazy-image" src="placeholder.jpg" data-src="image1.jpg" alt="Image 1">
  <!-- Placeholder for the second image -->
  <img class="lazy-image" src="placeholder.jpg" data-src="image2.jpg" alt="Image 2">
  <!-- Add more placeholders as needed -->
</div>

<script>
    // Function to load images lazily
    function lazyLoadImages() {
        document.querySelectorAll('.lazy-image').forEach(img => {
            const rect = img.getBoundingClientRect();
            if (rect.top >= 0 && rect.bottom <= window.innerHeight) {
                // Image is in the viewport, load it
                img.src = img.getAttribute('data-src');
            }
        });
    }

    // Attach lazyLoadImages function to the scroll event
    window.addEventListener('scroll', lazyLoadImages);

    // Initial call to load images that are already in the viewport
    lazyLoadImages();
</script>

</body>
</html>
