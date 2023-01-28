from contextlib import contextmanager

import zmq


@contextmanager
def zmq_no_linger_context():
    context = zmq.Context()
    try:
        yield context
    finally:
        context.destroy(linger=0)