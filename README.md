# Enpassant
Ingests chess board state sent from a DGT board and forwards it to clients listening for updates. SignalR is used for communication. Enpassant will receive messages from a client that is running the following code:
https://github.com/emilmork/dgt-chessboard-bluetooth

**This app is hosted here:** https://enpassanthub.azurewebsites.net/

## Hubs
The app exposes two hubs:

`{baseUrl}/ingestion` is used to push board states. Clients using this hub should send messages titled `BoardUpdate`.

`{baseUrl}/chessEvents` is used to listen to board states. Clients using this hub should listen for messages titled `BoardUpdate`. Clients may also invoke `LastUpdate` to get the last board state.

## How to connect to Enpassant hub

Read the following documentation for information on how to use SignalR from JavaScript:
https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-3.0
