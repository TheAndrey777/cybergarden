const DEFAULT_TIME = 8000;
const DEFAULT_COLOR_KEY = "green";
const DEFAULT_COLOR = {
    green: {start: "33B30A", finish: "7AC234"},
    blue: {start: "4853A9", finish: "5A67CE"},
    red: {start: "D7317A", finish: "B22865"}
};


class Toaster {
    constructor(toaster) {
        if (toaster) this._defaultTime = toaster.time || DEFAULT_TIME;
    }

    addToast(toast) {
        let color = DEFAULT_COLOR[toast.color || DEFAULT_COLOR_KEY];
        Toastify({
            text: (toast.title ? (toast.title + "\n") : "") + toast.message || "",
            duration: toast.time || this._defaultTime,
            destination: "",
            newWindow: true,
            close: false,
            gravity: "top",
            position: "right",
            stopOnFocus: true,
            style: {
                background: "linear-gradient(to right, #".concat(color.start, ", #").concat(color.finish),
            },
            onClick: function () {
            }
        }).showToast();
    }
}