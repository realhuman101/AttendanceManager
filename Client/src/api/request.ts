import * as data from './config.json';

const mainURL = data.url;

export async function get(url: string) {
	const response = await fetch(mainURL+url, {
		credentials: 'include',
		method: "GET",
		headers: {
			"Accept": "*/*",
			"Access-Control-Allow-Credentials": "true"
		}
	})
	return await response.json();
}

export async function post(url: string, data = {}) {
	const response = await fetch(mainURL+url, {
		credentials: 'include',
		mode: "cors",
		method: "POST",
		headers: {
			'Host': "localhost:7270",
			"Accept": "*/*",
			"Content-Type": "application/json",
			"Access-Control-Allow-Credentials": "true"
		},
		body: JSON.stringify(data)
	})
	return await response;
}
