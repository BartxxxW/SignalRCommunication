
(async function () {
    const message = document.getElementById("messageToSend");

    $(message).on("input", async function ()  {

        const msg = $(message).val();

        if (!msg || msg == '') { return }

        try {
            await connection.invoke("SendToDesktopClient", msg);
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


    connection.on("ReceiveDesktopMessage", (message) => {
        $("#receivedMsg").text(message);

    });

    start();
})();



