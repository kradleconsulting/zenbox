const dp = new DayPilot.Scheduler("dp", {
    startDate: "2025-10-01",
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
        const result = await app.editEvent(args.e.data);
        if (!result) {
            return;
        }
        dp.events.update(result);
    },
});

dp.init();
dp.scrollTo("2025-10-01");

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
    barColor(i) {
        const colors = ["#3c78d8", "#6aa84f", "#f1c232", "#cc0000"];
        return colors[i % 4];
    },
    barBackColor(i) {
        const colors = ["#a4c2f4", "#b6d7a8", "#ffe599", "#ea9999"];
        return colors[i % 4];
    },
    async editEvent(data) {
        const form = [
            { name: "Text", id: "text"},
            { name: "Start", id: "start", type: "datetime", disabled: true },
            { name: "End", id: "end", type: "datetime", disabled: true },
            { name: "Resource", id: "resource", options: dp.resources}
        ];
        const modal = await DayPilot.Modal.form(form, data);
        if (modal.canceled) {
            return null;
        }
        return modal.result;
    },
    loadData() {
        const resources = [
          {name: "Person 1", id: "A"},
          {name: "Person 2", id: "B"},
          {name: "Person 3", id: "C"},
          {name: "Person 4", id: "D"},
        ];

        const events = [];
        for (let i = 0; i < 12; i++) {
            const duration = Math.floor(Math.random() * 6) + 1; // 1 to 6
            const durationDays = Math.floor(Math.random() * 6) + 1; // 1 to 6
            const start = Math.floor(Math.random() * 6) + 2; // 2 to 7

            const e = {
                start: new DayPilot.Date("2025-10-01T12:00:00").addDays(start),
                end: new DayPilot.Date("2025-10-01T12:00:00").addDays(start).addDays(durationDays).addHours(duration),
                id: i + 1,
                resource: String.fromCharCode(65 + i),
                text: "Event " + (i + 1),
                barColor: app.barColor(i),
                barBackColor: app.barBackColor(i)
            };

            events.push(e);
        }

        dp.update({resources, events});
    },
};

app.loadData();
