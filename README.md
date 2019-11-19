# Enpassant
Ingests chess board state sent from a DGT board and forwards it to clients listening for updates. SignalR is used for communication. Enpassant will receive messages from a client that is running the following code:
https://github.com/emilmork/dgt-chessboard-bluetooth

**This app is hosted here:** https://enpassanthub.azurewebsites.net/

## Hubs
**Note:** Breaking changes!
The app exposes a single hub. Connect to `{baseUrl}/chessEvents`.

This hub supports three messages:

- To push new board state, send messages titled `PushBoardState`.
- To listen for new board state, listen for messages titled `NewBoardState`.
- To get the last known board state, invoke `LastUpdate`. Enpassant will respond with the last update.

## How to connect to Enpassant hub

Read the following documentation for information on how to use SignalR from JavaScript:
https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-3.0
