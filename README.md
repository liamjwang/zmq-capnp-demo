
## Unity Dev Setup
- Clone the repository
- Install the exact unity version found in [zmq-capnp-unity/ProjectSettings/ProjectVersion.txt](zmq-capnp-unity/ProjectSettings/ProjectVersion.txt)
- Open the unity project
- If there are errors, close and open the unity project

## Python Dev Setup
- Install mambaforge [https://github.com/conda-forge/miniforge#mambaforge](https://github.com/conda-forge/miniforge#mambaforge)
- `cd zmq-capnp-python`
- `mamba env create -f env.yml`
- `mamba activate demoenv`
- `python sender.py`

## Compiling capnp spec
- Install capnproto and capnpc-csharp-win-x86 using chocolatey: [https://github.com/c80k/capnproto-dotnetcore](https://github.com/c80k/capnproto-dotnetcore)
- Run ./capnp_compile.cmd

## Resources
- https://zeromq.org/
- https://learning-0mq-with-pyzmq.readthedocs.io/en/latest/pyzmq/pyzmq.html
- https://netmq.readthedocs.io/en/latest/introduction/
- https://capnproto.org/
- https://github.com/c80k/capnproto-dotnetcore
- https://github.com/GlitchEnzo/NuGetForUnity#unity-20193-or-newer

## Troubleshooting
- Close and open unity