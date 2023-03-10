# ZMQ & Cap'n Proto Demo

Starter code for using zmq and capnp to do networking between python and unity.
The unity project also contains utilities and prefabs for HoloLens 2, such as:
- QR code tracking
- MRTK keypad interface for entering ZMQ server IP
- Scan QR code with ZMQ IP address to connect

## Python Dev Setup
- Install mambaforge [https://github.com/conda-forge/miniforge#mambaforge](https://github.com/conda-forge/miniforge#mambaforge)
- `cd zmq-capnp-python`
- `mamba env create -f env.yml`
- `mamba activate demoenv`
- `python sender.py`

## Unity Dev Setup
- Clone the repository
- Install the exact unity version found in [zmq-capnp-unity/ProjectSettings/ProjectVersion.txt](zmq-capnp-unity/ProjectSettings/ProjectVersion.txt)
- Open the unity project
- If there are errors, close and open the unity project
- Run the unity project

## Compiling capnp spec
- Install capnproto and capnpc-csharp-win-x86 using chocolatey: [https://github.com/c80k/capnproto-dotnetcore](https://github.com/c80k/capnproto-dotnetcore)
    - `choco install capnproto`
    - `choco install capnpc-csharp-win-x86`
- Run ./capnp_compile.cmd

## Resources
- https://zeromq.org/
- https://learning-0mq-with-pyzmq.readthedocs.io/en/latest/pyzmq/pyzmq.html
- https://netmq.readthedocs.io/en/latest/introduction/
- https://capnproto.org/
- https://github.com/c80k/capnproto-dotnetcore
- https://github.com/GlitchEnzo/NuGetForUnity#unity-20193-or-newer
- https://github.com/OpenAvikom/mr-grpc-unity
- https://github.com/rderbier/Hololens-QRcodeSample
- https://game.ci/

## Troubleshooting
- Close and open unity