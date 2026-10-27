import http from 'k6/http';
import { sleep, check } from 'k6';
import { Counter } from 'k6/metrics';

const successfull = new Counter('successful_200');
const conflicts = new Counter('conflicts_409');
const others = new Counter('others_status');

export const options = {
  scenarios: {
    race: {
      executor: 'per-vu-iterations',
      vus: 100,
      iterations: 1,
      maxDuration: '30s',
    },
  },
  thresholds: {
    successful_200: ['count==1'],
    conflicts_409: ['count==99'],
    others_status: ['count==0'],
  },
};

export function setup() {
  http.post('http://localhost:5016/Tickets/Reset');
}

export default function () {
  const result = http.post('http://localhost:5016/Tickets/Seat');

  if (result.status === 200) {
    successfull.add(1);
  } else if (result.status === 409) {
    conflicts.add(1);
  } else {
    others.add(1);
  }

}

export function teardown() {
  const res = http.get('http://localhost:5016/Tickets/Seat');
  console.log(`Expected: 1 | Received: ${res.body}`);
  check(res, { 'Seats reserved == 1': (r) => r.body === '1' });
}