export interface BaseResponse<TResult> {
    isOk: boolean;
    message: string;
    result: TResult;
}