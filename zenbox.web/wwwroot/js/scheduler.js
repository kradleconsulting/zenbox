const dp = new DayPilot.Scheduler("dp", {
    startDate: DayPilot.Date.today().firstDayOfWeek(),
    cellWidth: 40,
    days: 365,
    scale: "Hour",
    cellDuration: 240,
    timeline: generateTimeline(),
    timeHeaders: [
        { groupBy: "Month", format: "MMMM yyyy"},
        { groupBy: "Day", format: "d" },
        { groupBy: "Cell", format: "HH:mm" }
    ],
    heightSpec: "Max",
    height: 400,
    contextMenu: new DayPilot.Menu({
        items: [
            {
                text: "Edit",
                onClick: async (args) => {
                    const result = await app.editEvent(args.source.data);
                    if (!result) {
                        return;
                    }
                    dp.events.update(result);
                }
            },
            {
                text: "-"
            },
            {
                text: "Delete",
                onClick: (args) => {
                    dp.events.remove(args.source);
                }
            },
        ]
    }),
    onTimeRangeSelected: async (args) => {
        const data = {
            start: args.start,
            end: args.end,
            id: DayPilot.guid(),
            resource: args.resource,
            text: "New event"
        };
        const result = await app.editEvent(data);
        dp.clearSelection();
        if (!result) {
            return;
        }
        dp.events.add(result);
    },

    onEventClick: async (args) => {
        const result = await editEvent(args.e.data);
        if (!result) {
            return;
        }
        dp.events.update(result);
    },

    async editEvent(data) {
        const form = [
            { name: "Text", id: "text" },
            { name: "Start", id: "start", type: "datetime", disabled: true },
            { name: "End", id: "end", type: "datetime", disabled: true },
            { name: "Resource", id: "resource", options: dp.resources }
        ];
        const modal = await DayPilot.Modal.form(form, data);
        if (modal.canceled) {
            return null;
        }
        return modal.result;
    },


});

function generateTimeline() {

    const timeline = [];

    const first = DayPilot.Date.today();
    const days = 30;

    for (let i = 0; i < days; i++) {
        const day = first.addDays(i);
        const start = day.addDays(-1).addHours(22);
        const end = start.addHours(8);

        timeline.push({ start, end });
        timeline.push({ start: start.addHours(8), end: start.addHours(16) });
        timeline.push({ start: start.addHours(16), end: start.addHours(24) });
    }

    return timeline;
}

const app = {

    init() {
        const events = [
            {
                id: "1",
                start: DayPilot.Date.today().addHours(10),
                end: DayPilot.Date.today().addHours(12),
                text: "Event 1",
                resource: "R1"
            }
        ];
        const resources = [
            { name: "Resource 1", id: "R1" },
            { name: "Resource 2", id: "R2" },
            { name: "Resource 3", id: "R3" },
            { name: "Resource 4", id: "R4" }
        ];

        //dp.update({ resources, events });
    },

    barColor(i) {
        const colors = ["#3c78d8", "#6aa84f", "#f1c232", "#cc0000"];
        return colors[i % 4];
    },

    barBackColor(i) {
        const colors = ["#a4c2f4", "#b6d7a8", "#ffe599", "#ea9999"];
        return colors[i % 4];
    }
};

dp.init();
app.init();

dp.events.load("/events");
dp.rows.load("/resources");