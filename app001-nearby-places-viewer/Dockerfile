# syntax=docker/dockerfile:1
FROM python:3-alpine
WORKDIR /app
COPY . .
RUN python -m pip install -r requirements.txt
CMD python app.py --host 0.0.0.0 --port 80
