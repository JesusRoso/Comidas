// Caution! Be sure you understand the caveats before publishing an application with
// offline support. See https://aka.ms/blazor-offline-considerations
//self.addEventListener('fetch', function (event) { });

self.addEventListener('push', event => {
    const payload = event.data.json();

    event.waitUntil(
        self.registration.showNotification('Nueva Comida', {
            body: payload.titulo,
            data: { url: payload.url }
        })
    );
});

self.addEventListener('notificationclick', event => {
    event.notification.close();
    event.waitUntil(clients.openWindow(event.notification.data.url));
});
