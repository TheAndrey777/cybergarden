const DEFAULT_TIME = 8000;

class Toaster {
    constructor(toaster) {
        this.defaultTime = toaster.time || DEFAULT_TIME;
    }

    addToast(toast) {
        Toastify({
            text: (toast.sender ? (toast.sender + "\n") : "") + toast.message || "",
            duration: toast.time || this.defaultTime,
            destination: "",
            newWindow: true,
            close: true,
            gravity: "top",
            position: "right",
            stopOnFocus: true,
            style: {
                background: "linear-gradient(to right, #33B30A, #7AC234)",
            },
            onClick: function () {
            }
        }).showToast();
    }
}