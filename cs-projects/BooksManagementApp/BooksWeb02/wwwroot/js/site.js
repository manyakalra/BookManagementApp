// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function deleteCard() {
    // Display a confirmation dialog box
    var result = window.confirm("Are you sure you want to delete the card?");

    if (result) {
        // If the user clicked "OK" in the dialog box
        // Here is where you would place the actual logic to delete the card.
        // This could involve making an API request, modifying the DOM, or other actions.

        // For this example, let's assume we have a card element with an ID "cardToDelete"
        var cardToDelete = document.getElementById("cardToDelete");
        if (cardToDelete) {
            cardToDelete.style.display = "none"; // Hide the card
            confirm("Card deleted!");
        } 
    } else {
        // If the user clicked "Cancel" in the dialog box
        var cardToShow = document.getElementById("cardToDelete");
        if (cardToShow) {
            cardToShow.style.display = "block"; // Show the card
            confirm("Card not deleted.");
        } 
    }
}
