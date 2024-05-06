
(async function () {
    const btnSend = document.getElementById("buttonSend");
    const message = document.getElementById("messageToSend");
    const receivedMsg = document.getElementById("receivedMsg");
 




    $(btnSend).click(async () => {

        const msg = $(message).val();

        if (!msg || msg == '') { return }

        try {
            await connection.invoke("Send", msg);
        } catch (err) {
            console.error(err);
        }

    })

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/messageHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };




    connection.onclose(async () => {
        await start();
    });


    connection.on("ReceiveMessage", (message) => {
        alert(message);
        $("#receivedMsg").text(message);

    });

    // Start the connection.
    start();
})();



