#!/usr/bin/python3

"""
    app.py

    MediaWiki API Demos

    Nearby places viewer app: Demo of geo search for wiki pages near a location using
    the Geolocation API and MediaWiki Action API's Geosearch module.

    MIT license
"""

from flask import Flask, request, render_template, jsonify
import requests
from haversine import haversine
import argparse


APP = Flask(__name__)
SESSION = requests.Session()
API_ENDPOINT = 'https://en.wikipedia.org/w/api.php'


@APP.route('/', methods=['GET'])
def index():
    """ Displays the index page accessible at '/'
    """
    message = '''APIs: /fetch_places_nearby?lat=20.1&lon=73.1&miles=2'''
    return message

@APP.route('/fetch_places_nearby', methods=['GET'])
def fetch_places_nearby():
    """ Fetches nearby places via MediaWiki Action API's Geosearch module
    """
    lat, lon = float(request.args.get('lat')), float(request.args.get('lon'))

    params = {
        "action": "query",
        "prop": "coordinates|pageimages|description|info",
        "inprop": "url",
        "pithumbsize": 144,
        "generator": "geosearch",
        "ggsradius": 10000,
        "ggslimit": 10,
        "ggscoord": str(lat) + "|" + str(lon),
        "format": "json",
    }

    res = SESSION.get(url=API_ENDPOINT, params=params)
    data = res.json()

    if 'query' not in data:
        return jsonify({
            'dump': data
        })

    places = data['query'] and data['query']['pages']
    results = []

    for k in places:
        title = places[k]['title']
        description = places[k]['description'] if "description" in places[k] else ''
        thumbnail = places[k]['thumbnail']['source'] if "thumbnail" in places[k] else ''
        article_url = places[k]['fullurl']

        cur_loc = (lat, lon)
        place_loc = (places[k]['coordinates'][0]['lat'], places[k]['coordinates'][0]['lon'])

        distance = round(haversine(cur_loc, place_loc, unit='mi'), int(request.args.get('miles')))

        results.append({
            'title': title,
            'description': description,
            'thumbnail': thumbnail,
            'articleUrl': article_url,
            'distance': distance
        })

    return jsonify(results)

""" Commment these two lines for deployment in Toolforge """
if __name__ == '__main__':
    parser = argparse.ArgumentParser(description='Get the host and port configuration')
    parser.add_argument('--host', dest='host', type=str, default='0.0.0.0')
    parser.add_argument('--port', dest='port', type=int, default=80)
    args = parser.parse_args()
    APP.run(debug=False, host=args.host, port=args.port)
