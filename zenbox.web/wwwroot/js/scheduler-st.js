const dp = new DayPilot.Calendar("dp", {
    viewType: "Week",
    timeRangeSelectedHandling: "Enabled",
    scale: "CellDuration",
    cellDuration: 30,
    onTimeRangeSelected: async (args) => {
        const modal = await DayPilot.Modal.prompt("Create a new event:", "Event 1");
        const calendar = args.control;
        calendar.clearSelection();
        if (modal.canceled) { return; }
        calendar.events.add({
            start: args.start,
            end: args.end,
            id: DayPilot.guid(),
            text: modal.result
        });
    },
    eventMoveHandling: "Update",
    onEventMoved: (args) => {
        console.log("Event moved: " + args.e.text());
    },
    eventResizeHandling: "Update",
    onEventResized: (args) => {
        console.log("Event resized: " + args.e.text());
    },
    eventClickHandling: "Disabled",
});

dp.init();
dp.events.load("/events");
