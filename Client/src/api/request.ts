import * as data from './config.json';

const mainURL = data.url;

export async function get(url: string) {
	const response = await fetch(mainURL+url, {
		credentials: 'same-origin',
		method: "GET",
		headers: {
			"Access-Control-Allow-Origin": "*",
			"Accept": "*/*"
		}
	})
	return await response.json();
}

export async function post(url: string, data = {}) {
	const response = await fetch(mainURL+url, {
		credentials: 'same-origin',
		method: "POST",
		headers: {
			"Access-Control-Allow-Origin": "*",
			"Accept": "*/*"
		},
		body: JSON.stringify(data)
	})
	return await response;
}
