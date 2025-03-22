import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { CommentGet, CommentPost } from "../Models/Comment";

const api = 'http://localhost:5240/api/comment/';

export const commentPostAPI = async (title: string, comment: string, symbol: string) => {
    try {
        const data = await axios.post<CommentPost>(api + `${symbol}`, {
            title: title,
            comment: comment
        })
        return data;
    } catch (error) {
        handleError(error);
    }
}

export const commentGetAPI = async (symbol: string) => {
    try {
        const data = await axios.get<CommentGet[]>(api + `?Symbol=${symbol}`);
        return data;
    } catch (error) {
        handleError(error);
    }
}