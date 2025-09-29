const dp = new DayPilot.Calendar("dp", {
    viewType: "Week",
    timeRangeSelectedHandling: "Enabled",
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

const app = {
    init() {
        const events = [
            {
                id: "1",
                start: DayPilot.Date.today().addHours(10),
                end: DayPilot.Date.today().addHours(12),
                text: "Event 1"
            }
        ];
        dp.update({ events });
    }
};
app.init();
