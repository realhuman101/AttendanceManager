import * as data from './config.json';

const mainURL = data.url;

const defaultHeaders = {
	'Host': "localhost:7270",
	"Accept": "*/*",
	"Content-Type": "application/json",
	"Access-Control-Allow-Credentials": "true",
	"Access-Control-Allow-Origin": mainURL
}

export async function get(url: string) {
	const response = await fetch(mainURL+url, {
		credentials: 'include',
		method: "GET",
		headers: defaultHeaders
	})
	return await response;
}

export async function post(url: string, data = {}) {
	const response = await fetch(mainURL+url, {
		credentials: 'include',
		mode: "cors",
		method: "POST",
		headers: defaultHeaders,
		body: JSON.stringify(data)
	})
	return await response;
}
