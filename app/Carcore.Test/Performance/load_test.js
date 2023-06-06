import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '3m', target: 100 }, // simulate ramp-up of traffic from 1 to 100 users over 5 minutes.
        { duration: '5m', target: 100 }, // stay at 100 users for 10 minutes
        { duration: '3m', target: 0 },  // ramp-down to 0 users
    ],

    thresholds: {
        http_req_duration: [{
            threshold: 'p(90) < 2000', // 99% of request mus complete below 150ms
            // abortOnFail: true,
        }]
    },
};

export default () => {
    http.get('https://localhost:7076/api/Car/getAllMakes')
    sleep(1);
}
